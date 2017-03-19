namespace PageAbstractions.UseCases.Tests.Abstractions
{
    public abstract class PageTests
    {
        protected string chromeDriverDirectory = @"C:\Users\Kaio\Documents\Projects\PageAbstractions\PageAbstractions\PageAbstractions.UseCases.Tests";

        public abstract void Setup();

        public abstract void TearDown();
    }
}
