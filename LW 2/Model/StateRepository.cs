using System.Text.Json;

namespace LW_2.Model
{
    public class StateRepository
    {
        private IList<State> _state = [];

        public async Task<IList<State>> GetAllAsync()
        {
            using var stream = File.OpenText("db.json");
            if (stream != null)
                _state = JsonSerializer.Deserialize<IList<State>>(await stream.ReadToEndAsync()) ?? [];
            return _state;
        }

        public async Task AddAsync(State state)
        {
            _state.Add(state);
            var json = JsonSerializer.Serialize(_state);
            await File.WriteAllTextAsync("db.json", json);
        }

        public async Task DeleteAsync(Guid guid)
        {
            State? state = _state.SingleOrDefault(s => s.Id == guid);
            if (state != null)
            {
                _state.Remove(state);
                var json = JsonSerializer.Serialize(_state);
                await File.WriteAllTextAsync("db.json", json);
            }
        }
    }
}
