namespace ATEC_BOOK_LENDING.DTO
{
    public class UserDTO
    {
        public long UserId { get; set; }

        public string? Name { get; set; }

        public string? MiddleName { get; set; }

        public string? Surname { get; set; }

        public bool? Active { get; set; }
    }
}
