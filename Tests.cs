
namespace FailingCollectionFixture;

[Collection("Collection")]
public sealed class Tests
{
    public Tests(CollectionFixture fixture)
    {
    }

    [Fact(Skip = "It will fail anyway.")]
    public void Test()
    {
    }
}


public sealed class CollectionFixture : IAsyncLifetime
{
    public Task DisposeAsync()
    {
        throw new Exception("Failed when disposing.");
    }

    public Task InitializeAsync()
    {
        throw new Exception("Failed when initializing");
    }
}

[CollectionDefinition("Collection")]
public sealed class TestsCollection : ICollectionFixture<CollectionFixture>
{
}