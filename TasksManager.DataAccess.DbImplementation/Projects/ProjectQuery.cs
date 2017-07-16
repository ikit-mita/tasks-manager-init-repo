using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Projects;
using TasksManager.Db;
using TasksManager.Entities;
using TasksManager.ViewModel.Projects;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class ProjectQuery : IProjectQuery
    {
        private TasksContext Context { get; }
        public ProjectQuery(TasksContext context)
        {
            Context = context;
        }

        public async Task<ProjectResponse> RunAsync(int projectId)
        {
            ProjectResponse response = await Context.Set<Project>()
                .Select(p => new ProjectResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    OpenTasksCount = p.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed)
                })
                .FirstOrDefaultAsync(pr => pr.Id == projectId);

            return response;
        }
    }
}
