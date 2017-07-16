using System.Threading.Tasks;
using TasksManager.ViewModel;
using TasksManager.ViewModel.Projects;

namespace TasksManager.DataAccess.Projects
{
    public interface IProjectsListQuery
    {
        Task<ListResponse<ProjectResponse>> RunAsync(ProjectFilter filter, ListOptions options);
    }
}
