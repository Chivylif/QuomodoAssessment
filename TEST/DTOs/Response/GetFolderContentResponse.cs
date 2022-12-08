using TEST.Models;

namespace TEST.DTOs.Response
{
    public class GetFolderContentResponse
    {
        public string Folder { get; set; }
        public List<string> SubFolders { get; set; }
        public List<string> Files { get; set; }
        public int FolderCount { get; set; } = 0;
        public int FileCount { get; set; } = 0;
    }
}
