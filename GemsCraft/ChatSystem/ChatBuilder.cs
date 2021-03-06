﻿using System;
using System.Collections.Generic;
using System.Linq;
using GemsCraft.AppSystem.Exceptions;
using LightJson;
using LightJson.Serialization;

namespace GemsCraft.ChatSystem
{
    public class ChatBuilder
    {
        private readonly JsonObject _json = new JsonObject();
        private readonly string _text;
        public ChatBuilder() { }
        public ChatBuilder(string text)
        {
            if (text.Length > 32767)
            {
                throw new ChatBuilderException("Text is too long. Max is 32767. Length = " + text.Length);
            }
            _text = text;

        }

        public string Generate()
        {
            if (_json.Count == 0) throw new ChatBuilderException("No items added.");
            JsonWriter writer = new JsonWriter(true);
            return writer.Serialize(_json);
        }

        public void SetTranslated(string item)
        {
            if (item == null) return;
            _json.Add("translate", item);
        }

        public void AddContent(ChatDetail[] chats)
        {
            if (chats == null) throw new ArgumentNullException(nameof(chats));
            List<JsonObject> items = chats.Select(item => new JsonObject
                {
                    {"text", item.Text},
                    {"bold", item.IsBold},
                    {"italic", item.IsItalics},
                    {"underlined", item.IsUnderlined},
                    {"strikethrough", item.IsStrikethrough},
                    {"obfuscated", item.IsInsane},
                    {"color", item.Color}
                })
                .ToList();
            List<JsonValue> itemsJson = items.Select(j => new JsonValue(j)).ToList();
            _json.Add("with", new JsonArray(itemsJson.ToArray()));
        }
    }

    public class ChatDetail
    {
        public bool IsBold;
        public bool IsItalics;
        public bool IsUnderlined;
        public bool IsStrikethrough;
        public bool IsInsane;
        public string Color;
        public string Inserts;
        // TODO: Click Events
        // TODO: Hover Events
        public string Text;
        public ChatDetail(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }


    }
}