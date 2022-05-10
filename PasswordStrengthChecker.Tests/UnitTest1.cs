using Xunit;

namespace PasswordStrengthChecker.Tests;

public class UnitTest1
{
    private readonly PasswordStrengthChecker _passwordStrengthChecker = new();

    [Theory]
    [InlineData("aaaaaaaa1", true)]
    [InlineData("1", false)]
    public void Check_ReturnsTrueIfPasswordIsAtLeast7Characters(string password, bool expected)
    {
        var actual = _passwordStrengthChecker.Check(password);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("aaaaaaaa1", true)]
    [InlineData("1111111", false)]
    [InlineData("1", false)]
    public void Check_ReturnsTrueIfPasswordContainsAtLeast1Letter(string password, bool expected)
    {
        var actual = _passwordStrengthChecker.Check(password);
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData("aaaaaaaa1", true)]
    [InlineData("aaaaaaaaa", false)]
    [InlineData("1111111", false)]
    [InlineData("1", false)]
    public void Check_ReturnsTrueIfPasswordContainsAtLeast1Digit(string password, bool expected)
    {
        var actual = _passwordStrengthChecker.Check(password);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("aaaaaaaa12", true)]
    [InlineData("aaaaaaaa1", false)]
    [InlineData("1", false)]
    public void CheckAdmin_ReturnsTrueIfPasswordIsAtLeast10Characters(string password, bool expected)
    {
        var actual = _passwordStrengthChecker.CheckAdmin(password);
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData("aaaaaaaa1 ", true)]
    [InlineData("aaaaaaaa1@", true)]
    [InlineData("aaaaaaaa1", false)]
    [InlineData("1", false)]
    public void CheckAdmin_ReturnsTrueIfPasswordContainsAtLeast1SpecialCharacter(string password, bool expected)
    {
        var actual = _passwordStrengthChecker.CheckAdmin(password);
        
        Assert.Equal(expected, actual);
    }
}