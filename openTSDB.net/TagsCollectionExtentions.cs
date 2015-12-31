﻿using System;
using openTsdbNet.models;

namespace openTsdbNet
{
    public static class TagsCollectionExtentions
    {
        public static TagsCollection AddTag(this TagsCollection tagsCollection, string tagName, string tagValue)
        {
            if(string.IsNullOrWhiteSpace(tagName)) throw new ArgumentException("Tag name can not be null or empty", nameof(tagName));
            if(string.IsNullOrWhiteSpace(tagValue)) throw new ArgumentException("Tag value can not be null or empty", nameof(tagValue));

            tagsCollection?.Add(tagName, tagValue);

            return tagsCollection;
        }

        public static TagsCollection SetHost(this TagsCollection tagsCollection, string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName))
            {
                throw new ArgumentException("The host name may not be null", nameof(hostName));
            }

            return tagsCollection.AddTag(TagNames.HOST, hostName);
        }

        public static TagsCollection SetHost(this TagsCollection tagsCollection, IHostNameProvider hostNameProvider)
        {
            return tagsCollection.AddTag(TagNames.HOST, hostNameProvider?.GetHostName());
        }
    }
}