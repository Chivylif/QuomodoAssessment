using System.ComponentModel.DataAnnotations;

namespace TEST.DTOs.Requests
{
    public class GetFolderContentsRequest
    {
        public int? FolderId { get; set; }
        public string FolderPath { get; set; } = "";
    }
}
