using System.Reflection;

[Developer("Edson Lima", "31")]
class Program
{
    public static void Main(string[] args)
    {
        
        //GetAssemblyMetadata();
        //GetAttribute(typeof(Program));
        GetAttributes(typeof(Program));
    }

    public static void GetAssemblyMetadata()
    {
        Assembly assembly = Assembly.Load("System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e");
        var pubTypesQuery = from type in assembly.GetTypes()
                            where type.IsPublic
                            from method in type.GetMethods()
                            where method.ReturnType.IsArray == true
                                || (method.ReturnType.GetInterface(
                                    typeof(System.Collections.Generic.IEnumerable<>).FullName!) != null
                                && method.ReturnType.FullName != "System.String")
                            group method.ToString() by type.ToString();

        foreach (var groupOfMethods in pubTypesQuery)
        {
            Console.WriteLine("Type: {0}", groupOfMethods.Key);
            foreach (var method in groupOfMethods)
            {
                Console.WriteLine("  {0}", method);
            }
        }
    }

    public static void GetAttributes(Type t)
    {
        var attributes = Attribute.GetCustomAttributes(t);

        foreach(var attr in attributes)
        {
            if (attr == null)
            {
                System.Console.WriteLine("Atributo não encontrado.");
            }
            else
            {
                System.Console.WriteLine("O atributo é: {0}", attr);
            }
        }
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

