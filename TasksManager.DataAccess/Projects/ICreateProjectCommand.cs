using System.Threading.Tasks;
using TasksManager.ViewModel.Projects;

namespace TasksManager.DataAccess.Projects
{
    public interface ICreateProjectCommand
    {
        Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request);
    }
}
