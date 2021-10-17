using DYG.CaseStudy.Core.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYG.CaseStudy.Core.Entities2
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class MainCategory
    {
        public string Title { get; set; }
        public string Slug { get; set; }
    }

    public class SourcesData
    {
        public string _id { get; set; }
        public string Title { get; set; }
    }

    public class PublishedAccount
    {
        public string _id { get; set; }
        public string Email { get; set; }
    }

    public class CreatedAccount
    {
        public string _id { get; set; }
        public string Email { get; set; }
    }

    public class Content
    {
        public string _t { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Story
    {
        public string _id { get; set; }
        public List<Content> Contents { get; set; }
    }

    public class Root
    {
        

        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Spot { get; set; }
        public DateTime PublishedTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<string> NewsKeywords { get; set; }
        public MainCategory MainCategory { get; set; }
        public List<SourcesData> SourcesData { get; set; }
        public PublishedAccount PublishedAccount { get; set; }
        public CreatedAccount CreatedAccount { get; set; }
        public Story Story { get; set; }
        public string MainArtUrl { get; set; }
    }
}
