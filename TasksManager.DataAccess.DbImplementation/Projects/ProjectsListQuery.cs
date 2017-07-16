using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Projects;
using TasksManager.Db;
using TasksManager.Entities;
using TasksManager.ViewModel;
using TasksManager.ViewModel.Projects;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class ProjectsListQuery : IProjectsListQuery
    {
        private TasksContext Context { get; }
        public ProjectsListQuery(TasksContext context)
        {
            Context = context;
        }

        public async Task<ListResponse<ProjectResponse>> RunAsync(ProjectFilter filter, ListOptions options)
        {
            IQueryable<ProjectResponse> query = Context.Set<Project>()
                .Select(p => new ProjectResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    OpenTasksCount = p.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed)
                });

            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();

            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);

            return new ListResponse<ProjectResponse>
            {
                Items = await query.ToListAsync(),
                Page = options.Page,
                PageSize = options.PageSize ?? totalCount,
                Sort = options.Sort,
                TotalItemsCount = totalCount
            };
        }

        private IQueryable<ProjectResponse> ApplyFilter(IQueryable<ProjectResponse> query, ProjectFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(pr => pr.Id == filter.Id);
            }

            if (filter.Name != null)
            {
                query = query.Where(pr => pr.Name.StartsWith(filter.Name));
            }

            if (filter.OpenTasksCount != null)
            {
                if (filter.OpenTasksCount.From != null)
                {
                    query = query.Where(pr => pr.OpenTasksCount >= filter.OpenTasksCount.From);
                }

                if (filter.OpenTasksCount.To != null)
                {
                    query = query.Where(pr => pr.OpenTasksCount <= filter.OpenTasksCount.To);
                }
            }

            return query;
        }
    }
}
