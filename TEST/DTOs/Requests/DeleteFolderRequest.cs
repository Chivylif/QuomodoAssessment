using System.ComponentModel.DataAnnotations;

namespace TEST.DTOs.Requests
{
    public class DeleteFolderRequest
    {
        [Required]
        public int FolderId { get; set; }
        public string ParentFolderPath { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
