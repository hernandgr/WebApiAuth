using AppAuthDemo.Api.Entities;

namespace AppAuthDemo.Api.Data
{
    public class AuthRepository
    {
        public Client FindClient(string clientId)
        {
            // Replace with a repo
            return new Client
            {
                Id = "AppAuthDemo",
                Secret = "lCXDroz4HhR1EIx8qaz3C13z/quTXBkQ3Q5hj7Qx3aA=",
                Name = "Console app",
                Active = true,
                ApplicationType = ApplicationType.NativeConfidential
            };
        }
    }
}