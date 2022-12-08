using TEST.DTOs.Requests;
using TEST.DTOs.Response;
using TEST.Models;

namespace TEST.Services.DatabaseServices
{
    public interface IFolderServices
    {
        Task<GetFolderContentResponse> GetFolderContents(int Id);
        Task<Folder> CreateFolder(string folderName);
        Task<Folder> CreateSubFolder(CreateSubFolderRequest request);
        Task<bool> DeleteFolder(DeleteFolderRequest request);
        Task<bool> RenameFolder(RenameFolderRequest request);
        Task<IEnumerable<Folder>> GetAllFolders();
    }
}

