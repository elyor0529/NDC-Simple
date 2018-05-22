
namespace NCD.Infrastructure.Helpers
{
    using RazorEngine.Templating;
    using System;
    using System.IO;

    public static class RazorHelper
    {
        /// <summary>
        /// Razor engine compile to HTML code
        /// </summary>
        /// <param name="path"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string Compile(string path, object model)
        {
            //path
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("path");

            //model
            if (model == null)
                throw new ArgumentNullException("model");

            var templateService = new TemplateService();
            var template = File.ReadAllText(path);
            var cache = model.GetHashCode().ToString();

            return templateService.Parse(template, model, null, cache);
        }

    }
}
