using System.ComponentModel.DataAnnotations;

namespace TEST.DTOs.Requests
{
    public class CreateSubFolderRequest
    {
        [Required]
        public string Name { get; set; }
        public int ParentId { get; set; }

        [Required]
        public string ParentFolderPath { get; set; }
    }
}
