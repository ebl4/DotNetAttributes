public class DeveloperAttribute : Attribute
{
    private string name;
    private string level;
    private bool reviewed;

    public DeveloperAttribute(string name, string level)
    {
        this.name = name;
        this.level = level;
        this.reviewed = false;
    }

    public virtual string Level { get => level; }
    public virtual string Name { get => name; }
    public virtual bool Reviewed { get => reviewed; set => reviewed = value; }
}