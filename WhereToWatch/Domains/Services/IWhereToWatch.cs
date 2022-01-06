using WhereToWatch.Domains.Models;

namespace WhereToWatch.Domains.Services
{
    public interface IWhereToWatch
    {
        Task<IEnumerable<Streaming>> ListAsync();
    }
}
