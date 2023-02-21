using System;
namespace Pokedex.Data.Utils;

public class Utils
{
	public static string GetTableName(Type type)
	{
		dynamic? tableAttr = type.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");
		var name = string.Empty;

		if (tableAttr != null)
			name = tableAttr.Name;

		return name;
	}
}

