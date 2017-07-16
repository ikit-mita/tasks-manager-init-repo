using System.Threading.Tasks;
using TasksManager.ViewModel.Projects;

namespace TasksManager.DataAccess.Projects
{
    public interface IProjectQuery
    {
        Task<ProjectResponse> RunAsync(int projectId);
    }
}
