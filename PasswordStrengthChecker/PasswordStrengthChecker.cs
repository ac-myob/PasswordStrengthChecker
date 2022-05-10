namespace PasswordStrengthChecker;

public class PasswordStrengthChecker
{
    public bool Check(string password)
    {
        return _lengthChecker(password, 7) &&
               _letterChecker(password) &&
               _digitChecker(password);
    }
    
    private bool _lengthChecker(string password, int lowerBound)
    {
        return password.Length >= lowerBound;
    }
    
    private bool _letterChecker(string password)
    {
        return password.Any(char.IsLetter);
    }
    
    private bool _digitChecker(string password)
    {
        return password.Any(char.IsDigit);
    }
    
    public bool CheckAdmin(string password)
    {
        return Check(password) &&
               _lengthChecker(password, 10) &&
               _specialChecker(password);
    }

    private bool _specialChecker(string password)
    {
        return password.Any(p => !(char.IsLetter(p) && char.IsDigit(p)));
    }
}