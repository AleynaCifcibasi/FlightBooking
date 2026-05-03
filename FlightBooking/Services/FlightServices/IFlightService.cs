using FlightBooking.Dtos.FlightDtos;

namespace FlightBooking.Services.FlightServices
{
    public interface IFlightService
    {
        Task<List<ResultFlightDto>> GetAllFlightsAsync();
        Task<GetFlightByIdDto> GetFlightByIdAsync(string id); // sadece bu
        Task CreateFlightAsync(CreateFlightDto createFlightDto);
        Task DeleteFlightAsync(string id);
        Task UpdateFlightAsync(UpdateFlightDto updateFlightDto);
    }
}