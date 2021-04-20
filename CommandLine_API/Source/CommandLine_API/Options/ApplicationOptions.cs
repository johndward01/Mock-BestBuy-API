namespace CommandLine_API.Options
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Server.Kestrel.Core;

    /// <summary>
    /// All options for the application.
    /// </summary>
    public class ApplicationOptions
    {
        public ApplicationOptions() => this.CacheProfiles = new CacheProfileOptions();

        [Required]
        public CacheProfileOptions CacheProfiles { get; }

        [Required]
        public CompressionOptions Compression { get; set; } = default!;

        [Required]
        public ForwardedHeadersOptions ForwardedHeaders { get; set; } = default!;

        public KestrelServerOptions Kestrel { get; set; } = default!;
    }
}
