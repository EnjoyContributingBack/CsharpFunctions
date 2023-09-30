//C# functions commented by the ChatGPT
/*
This code defines a public static method named getDoubleValue that takes an object as an argument and attempts to convert it into a double value. 
a) It checks if the input d is null. If d is null, it returns 0. This means that if the input object is null, the method will return 0.
b) It checks if the input d is a database null value (DBNull). If d is a DBNull value, it also returns 0. 
  DBNull is a special value in .NET used to represent missing or nonexistent data in a database.
c) It converts the input object d to a string using Convert.ToString(d) and then trims the resulting string. 
    It checks if the trimmed string is an empty string (string.Empty). If it's an empty string, the method returns 0. 
    This means that if the input object is a string that's either null or consists of only whitespace characters after trimming, the method will return 0.
d) If none of the above conditions are met, it attempts to convert the input object d to a double using Convert.ToDouble(d). 
  If this conversion succeeds, it returns the converted double value.
e) If any exceptions occur during the conversion, the code catches them using a try...catch block. 
  If an exception is caught, it returns 0. 
  This ensures that if the input object cannot be successfully converted to a double for any reason, the method will return 0.
In summary, this method is designed to safely attempt to convert an input object to a double value, 
handling various scenarios such as null values, DBNull values, and empty strings, 
and returning 0 in case of any issues or failures during the conversion.
*/
public static double getDoubleValue(object d)
{
    if (d == null) return 0;
    if (Convert.IsDBNull(d)) return 0;
    if (Convert.ToString(d).Trim() == string.Empty) return 0;

    try
    {   return Convert.ToDouble(d);}
    catch { return 0; }
}

/*
This code defines a public static method named getTextValue that takes an object as an argument and attempts to convert it into a string value. 
a) It checks if the input d is null. If d is null, it returns an empty string (string.Empty). 
   This means that if the input object is null, the method will return an empty string.
b) It checks if the input d is a database null value (DBNull). If d is a DBNull value, it also returns an empty string (string.Empty). 
  This handles the case where the input object represents missing or nonexistent data in a database.
c) It converts the input object d to a string using Convert.ToString(d) and then trims the resulting string. 
  The trimmed string is then returned as the result of the method.
In summary, this method is designed to safely attempt to convert an input object to a string value, 
handling scenarios where the input object is null or represents a DBNull value, and returning 
the trimmed string representation of the input object in all other cases. 
If the input object cannot be converted to a string for any reason, it will return an empty string.
*/
public static string getTextValue(object d)
{
    if (d == null) return string.Empty;
    if (Convert.IsDBNull(d)) return string.Empty;

    return Convert.ToString(d).Trim();
}
