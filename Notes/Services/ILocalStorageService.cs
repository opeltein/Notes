using System.Threading.Tasks;

namespace Notes.Services
{
    public interface ILocalStorageService
    {
        Task<T?> Get<T>(string key);
        Task Set<T>(string key, T value);
    }
}
