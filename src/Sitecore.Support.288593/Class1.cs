using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.XA.Foundation.SitecoreExtensions.Pipelines.RenderField
{
  using Sitecore.Collections;
  using Sitecore.Data.Fields;
  using Sitecore.Pipelines.RenderField;

  public class SetImageStyleParameters
  {
    public void Process(RenderFieldArgs args)
    {
      if (args.FieldTypeKey == "image")
      {
        ImageField imageField = args.GetField();
        if (!string.IsNullOrWhiteSpace(imageField.VSpace + imageField.HSpace))// Patch 287589 reporting...
        {
          string arg = string.IsNullOrWhiteSpace(imageField.VSpace) ? "0" : imageField.VSpace;
          string arg2 = string.IsNullOrWhiteSpace(imageField.HSpace) ? "0" : imageField.HSpace;
          ((SafeDictionary<string, string>) args.Parameters)["style"] = string.Format("margin: {0}px {1}px", arg, arg2);
        }
      }
    }
  }
}