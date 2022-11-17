using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Neuroglia.Templating;
using Neuroglia.Templating.Services;
using Neuroglia.UnitTests.Cases.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Neuroglia.UnitTests.Cases.Templating
{

    public class RazorLightTemplateRendererTests
    {

        public RazorLightTemplateRendererTests()
        {
            ServiceCollection services = new();
            services.AddLogging();
            services.AddRazorLightTemplateRenderer(builder =>
            {
                builder.UseEmbeddedResourcesProject(typeof(RazorLightTemplateRendererTests))
                    .SetOperatingAssembly(typeof(RazorLightTemplateRendererTests).Assembly)
                    .UseMemoryCachingProvider();
            }, ServiceLifetime.Singleton);
            this.TemplateRenderer = services.BuildServiceProvider().GetRequiredService<ITemplateRenderer>();
        }

        ITemplateRenderer TemplateRenderer { get; }

        [Fact]
        public async Task RenderTemplate()
        {
            //arrange
            var model = new TestModel();
            var template = @"
    @model Neuroglia.UnitTests.Cases.Data.TestModel;
    @{
        string test this.Model?.Options[0];
    }
    <select>
        @foreach(string option in this.Model.Options)
        {
            <option value=""@option"">@option</option>
        }
    </select>
";

            //preassert
            model.Should().NotBeNull();
            model.Options.Should().NotBeNull();
            model.Options.Should().HaveCount(2);

            //act
            var rendered = await this.TemplateRenderer.RenderTemplateAsync(template, model);

            //assert
            rendered.Should().NotBeNullOrWhiteSpace();
        }

    }

}
