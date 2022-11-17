using FluentAssertions;
using Google.Protobuf.WellKnownTypes;
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
        string test = this.Model.Options[0];
    }
    <option>@test</option>

    <select>
        @foreach(string option in this.Model.Options)
        {
            <option value=""@option"">@option</option>
        }
    </select>
";

            //act
            var rendered = await this.TemplateRenderer.RenderTemplateAsync(template, model);

            //assert
            rendered.Should().NotBeNullOrWhiteSpace();
            rendered.Should().Contain("<option>option1</option>");
            rendered.Should().Contain("<select>");
            rendered.Should().Contain($"<option value=\"{model.Options[0]}\">{model.Options[0]}</option>");
            rendered.Should().Contain($"<option value=\"{model.Options[1]}\">{model.Options[1]}</option>");
            rendered.Should().Contain("</select>");
        }

    }

}
