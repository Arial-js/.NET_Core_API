namespace WebAPI.Util
{
    public interface IJwtAuthentication
    {
        string Authenticate(string username, string passoword);
    }
}
