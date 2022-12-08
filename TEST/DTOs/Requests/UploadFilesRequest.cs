using System.ComponentModel.DataAnnotations;

namespace TEST.DTOs.Requests
{
    public class UploadFilesRequest
    {
        [Required]
        public int FolderId { get; set; }
        public string FolderPath { get; set; }
        [Required]
        public IFormFile Files { get; set; }
    }
}
