﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedbugger
{
    public static class Extensions
    {
        //https://github.com/dedmen/ArmaDebugEngine/blob/master/BIDebugEngine/BIDebugEngine/breakPoint.cpp#L12 void BreakPoint::Serialize(JsonArchive& ar)
        /*
         *  {
         *      "action": {
         *          "code": "string",
         *          "basePath" : "string",
         *          "type": 0
         *      },
         *      "condition": "string",
         *      "filename": "string",
         *      "line": 0
         *  }
         */
        public static asapJson.JsonNode Serialize(this ArmA.Studio.Data.BreakpointInfo b)
        {
            var data = new asapJson.JsonNode(new Dictionary<string, asapJson.JsonNode>());
            var action = data.GetValue_Object()["action"] = new asapJson.JsonNode(new Dictionary<string, asapJson.JsonNode>());
            action.GetValue_Object()["code"] = new asapJson.JsonNode();
            action.GetValue_Object()["basePath"] = new asapJson.JsonNode();
            action.GetValue_Object()["type"] = new asapJson.JsonNode(2); //https://github.com/dedmen/ArmaDebugEngine/blob/master/BIDebugEngine/BIDebugEngine/breakPoint.h#L82
            data.GetValue_Object()["condition"] = string.IsNullOrWhiteSpace(b.SqfCondition) ? new asapJson.JsonNode() : new asapJson.JsonNode(b.SqfCondition);
            data.GetValue_Object()["filename"] = new asapJson.JsonNode(b.FileRef.ArmAPath.Replace('/', '\\').Replace(@"\\", @"\"));
            data.GetValue_Object()["line"] = new asapJson.JsonNode(b.Line);
            return data;
        }
    }
}
