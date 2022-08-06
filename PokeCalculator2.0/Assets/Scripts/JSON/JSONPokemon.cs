public class JSONPokemon
{
    public string name;
    public Sprites sprites = new Sprites();
    public Types[] types;

    [System.Serializable]
    public class Sprites
    {
        public string front_default;
    }

    [System.Serializable]
    public class Types
    {
        public int slot;
        public Type type;
    }

    [System.Serializable]
    public class Type
    {
        public string name;
    }
}
