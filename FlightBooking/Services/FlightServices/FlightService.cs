using AutoMapper;
using FlightBooking.Dtos.FlightDtos;
using FlightBooking.Entities;
using FlightBooking.Settings;
using MongoDB.Driver;

namespace FlightBooking.Services.FlightServices
{
    public class FlightService : IFlightService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Flight> _flightsCollection;

        public FlightService(IMapper mapper,IDatabaseSetting databaseSetting)
        {
            var client =new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);
            _flightsCollection = database.GetCollection<Flight>(databaseSetting.FlightCollectionName);  
            _mapper = mapper;
        }

        public async Task CreateFlightAsync(CreateFlightDto createFlightDto)
        {
            var values = _mapper.Map<Flight>(createFlightDto);
            await _flightsCollection.InsertOneAsync(values);    
        }

        public async Task DeleteFlightAsync(string id)
        {
            await _flightsCollection.DeleteOneAsync(x=> x.FlightId == id);
        }

        public async Task<List<ResultFlightDto>> GetAllFlightsAsync()
        {
            var values = await _flightsCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFlightDto>>(values);
        }

        public async Task<GetFlightByIdDto> GetFlightById(string id)
        {
            var value = await _flightsCollection.Find(x => x.FlightId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFlightByIdDto>(value);
        }
        public async Task<GetFlightByIdDto> GetFlightByIdAsync(string id)
        {
            var value = await _flightsCollection
                .Find(x => x.FlightId == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetFlightByIdDto>(value);
        }

        public async Task UpdateFlightAsync(UpdateFlightDto updateFlightDto)
        {
            var values = _mapper.Map<Flight>(updateFlightDto);
            await _flightsCollection.FindOneAndReplaceAsync(x => x.FlightId == updateFlightDto.FlightId, values);

        }
    }
}
