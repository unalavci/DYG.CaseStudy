using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace DYG.CaseStudy.Core.Entities
{

    public partial class JsonData
    {
        [JsonProperty("Root")]
        public Root Root { get; set; }

        [JsonProperty("MainCategory")]
        public MainCategory MainCategory { get; set; }

        [JsonProperty("SourcesData")]
        public SourcesDatum[] SourcesData { get; set; }

        [JsonProperty("PublishedAccount")]
        public EdAccount PublishedAccount { get; set; }

        [JsonProperty("CreatedAccount")]
        public EdAccount CreatedAccount { get; set; }

        [JsonProperty("Story")]
        public Story Story { get; set; }

        [JsonProperty("MainArtUrl")]
        public Uri MainArtUrl { get; set; }
    }

    public partial class EdAccount
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }
    }

    public partial class MainCategory
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Slug")]
        public string Slug { get; set; }
    }

    public partial class Root
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Spot")]
        public string Spot { get; set; }

        [JsonProperty("PublishedTime")]
        public DateTime PublishedTime { get; set; }

        [JsonProperty("CreatedTime")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("NewsKeywords")]
        public string[] NewsKeywords { get; set; }

        [JsonProperty("MainCategory")]
        public MainCategory MainCategory { get; set; }

        [JsonProperty("SourcesData")]
        public SourcesDatum[] SourcesData { get; set; }

        [JsonProperty("PublishedAccount")]
        public EdAccount PublishedAccount { get; set; }

        [JsonProperty("CreatedAccount")]
        public EdAccount CreatedAccount { get; set; }

        [JsonProperty("Story")]
        public Story Story { get; set; }

        [JsonProperty("MainArtUrl")]
        public Uri MainArtUrl { get; set; }
    }

    public partial class SourcesDatum
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }
    }

    public partial class Story
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("Contents")]
        public List<Content> Contents { get; set; }
    }

    public partial class Content
    {
        Dictionary<string, dynamic> kvp = new Dictionary<string, dynamic>();

        [JsonProperty("_t")]
        public string T { get; set; }

        [JsonProperty("Text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("ImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ImageUrl { get; set; }
    }

    public partial class JsonData
    {
        public static JsonData[] FromJson(string json) => JsonConvert.DeserializeObject<JsonData[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this JsonData[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }




}