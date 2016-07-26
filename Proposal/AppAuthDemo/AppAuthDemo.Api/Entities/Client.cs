namespace AppAuthDemo.Api.Entities
{
    public class Client
    {
        public string Id { get; set; }

        public string Secret { get; set; }

        public string Name { get; set; }

        public ApplicationType ApplicationType { get; set; }

        public bool Active { get; set; }
    }
}