using BlazorBootstrap;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SimpleBlazorApp.Models
{
	public class GiphyResponse
	{
		public List<GifData> Data { get; set; }
		public Meta Meta { get; set; }
		public Pagination Pagination { get; set; }
	}

	public class GifData
	{
		public string Type { get; set; }
		public string Id { get; set; }
		public string Url { get; set; }
		public string Slug { get; set; }
		public string BitlyGifUrl { get; set; }
		public string BitlyUrl { get; set; }
		public string EmbedUrl { get; set; }
		public string Username { get; set; }
		public string Source { get; set; }
		public string Title { get; set; }
		public string Rating { get; set; }
		public string ContentUrl { get; set; }
		public string SourceTld { get; set; }
		public string SourcePostUrl { get; set; }
		public int IsSticker { get; set; }
		public DateTime ImportDatetime { get; set; }
		public DateTime TrendingDatetime { get; set; }
		public Images Images { get; set; }
		public User User { get; set; }
		public string AnalyticsResponsePayload { get; set; }
		public Analytics Analytics { get; set; }
	}

	public class Images
	{
		public ImageData Original { get; set; }
		public ImageData FixedHeight { get; set; }
		public ImageData FixedHeightDownsampled { get; set; }
		public ImageData FixedHeightSmall { get; set; }
		public ImageData FixedWidth { get; set; }
		public ImageData FixedWidthDownsampled { get; set; }
		public ImageData FixedWidthSmall { get; set; }
	}

	public class ImageData
	{
		public string Height { get; set; }
		public string Width { get; set; }
		public string Size { get; set; }
		public string Url { get; set; }
		public string Mp4Size { get; set; }
		public string Mp4 { get; set; }
		public string WebpSize { get; set; }
		public string Webp { get; set; }
		public string Frames { get; set; }
		public string Hash { get; set; }
	}

	public class User
	{
		public string AvatarUrl { get; set; }
		public string BannerImage { get; set; }
		public string BannerUrl { get; set; }
		public string ProfileUrl { get; set; }
		public string Username { get; set; }
		public string DisplayName { get; set; }
		public string Description { get; set; }
		public string InstagramUrl { get; set; }
		public string WebsiteUrl { get; set; }
		public bool IsVerified { get; set; }
	}

	public class Analytics
	{
		public AnalyticsAction Onload { get; set; }
		public AnalyticsAction Onclick { get; set; }
		public AnalyticsAction Onsent { get; set; }
	}

	public class AnalyticsAction
	{
		public string Url { get; set; }
	}

	public class Meta
	{
		public int Status { get; set; }
		public string Msg { get; set; }
		public string ResponseId { get; set; }
	}

	public class Pagination
	{
		[JsonPropertyName("total_count")]
		public int TotalCount { get; set; }
		public int Count { get; set; }
		public int Offset { get; set; }
	}
}
