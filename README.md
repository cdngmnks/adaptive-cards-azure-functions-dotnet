# Adaptive Cards - Azure Functions (.NET)

Function returning an Adaptive Card rendered as HTML, using the [Adaptive Card .NET HTML SDK](https://docs.microsoft.com/en-us/adaptive-cards/sdk/rendering-cards/net-html/getting-started).

example request:
```javascript
{
    "template" : {
        "type": "AdaptiveCard",
        "version": "1.0",
        "body": [
            {
                "type": "TextBlock",
                "text": "Hello ${name}!"
            }
        ]
    },
    "data" : {
        "name" : "World"
    }
}
```

example response:
```javascript
{
  "type": "AdaptiveCard",
  "version": "1.0",
  "body": [
    {
      "type": "TextBlock",
      "text": "Hello World!"
    }
  ]
}
```

# References
* [Adaptive Cards](https://adaptivecards.io/)
* [Adaptive Card .NET HTML SDK](https://docs.microsoft.com/en-us/adaptive-cards/sdk/rendering-cards/net-html/getting-started)
* [Create C# function in Azure using VS Code](https://docs.microsoft.com/en-us/azure/azure-functions/create-first-function-vs-code-csharp)
* [Azure Functions JavaScript developer guide](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-node)

# Issues
To view or log issues, see [issues](https://github.com/cdngmnks/adaptive-cards-renderer-azure-function/issues).

# License
Copyright (c) codingmonkeys doo. All Rights Reserved. Licensed under the [MIT license](https://github.com/cdngmnks/adaptive-cards-renderer-azure-function/blob/master/LICENSE).
