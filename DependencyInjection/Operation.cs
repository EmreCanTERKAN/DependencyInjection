namespace DependencyInjection
{
    public class Operation : IOperationScoped, IOperationSingleton, IOperationTransient
    {
        public Operation() : this(Guid.NewGuid())
        {
            
        }

        public Operation(Guid id)
        {
            OperationId = id;
        }

        public Guid OperationId { get; set; }
    }
}
