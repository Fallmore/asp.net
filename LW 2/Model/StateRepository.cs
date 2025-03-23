using System.Text.Json;

namespace LW_2.Model
{
    public class StateRepository
    {
        private IList<State> _state = [];

        public IList<State> GetAll()
        {
            using var stream = File.OpenText("db.json");
            if (stream != null)
                _state = JsonSerializer.Deserialize<IList<State>>(stream.ReadToEnd()) ?? [];
            return _state;
        }

        public void Add(State state)
        {
            _state.Add(state);
            var json = JsonSerializer.Serialize(_state);
            File.WriteAllText("db.json", json);
        }
    }
}
