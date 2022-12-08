using TEST.DTOs.Requests;
using TEST.DTOs.Response;
using TEST.Models;

namespace TEST.Services.ServerServices
{
    public interface IFolderServicesServer
    {
        Task<GetFolderContentResponse> GetFolderContents(GetFolderContentsRequest request);
        Task<bool> CreateFolder(string folderName);
        Task<bool> CreateSubFolder(CreateSubFolderRequest request);
        Task<bool> DeleteFolder(DeleteFolderRequest request);
        Task<bool> RenameFolder(RenameFolderRequest request);
    }
}
    