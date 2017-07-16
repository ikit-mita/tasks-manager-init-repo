using System;
using System.Linq;
using System.Linq.Expressions;

namespace TasksManager.ViewModel
{
    public class RangeFilter<T> where T : struct
    {
        public T? From { get; set; }
        public T? To { get; set; }
    }
}
