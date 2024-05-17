namespace Shared
{
    public class DataTransferObjects
    {
        public record CompanyDto(Guid Id, string Name, string FullAddress);
        public record EmployeeDto(Guid Id, string Name, int Age, string Position);
        public record CompanyForCreationDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);
        public record EmployeeForCreationDto(string Name, int Age, string Position);
    }
}
