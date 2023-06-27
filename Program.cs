[Developer("Edson Lima", "31")]
class Program
{
    public static void Main(string[] args)
    {
        GetAttribute(typeof(Program));
    }

    public static void GetAttribute(Type t)
    {
        DeveloperAttribute myAttribute = 
        (DeveloperAttribute) Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute))!;

        if (myAttribute == null)
        {
            System.Console.WriteLine("Atributo não encontrado.");
        }
        else
        {
            System.Console.WriteLine("O atributo Name é: {0}", myAttribute.Name);
            System.Console.WriteLine("O atributo Level é: {0}", myAttribute.Level);
            System.Console.WriteLine("O atributo Reviwed é: {0}", myAttribute.Reviewed);
        }
    }
}

