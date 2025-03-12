namespace Parcia1.Models
{
    public class BaseModel
    { 
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string? EditeBy { get; set; }
        public DateTime? Edited { get; set; }
    }
}
