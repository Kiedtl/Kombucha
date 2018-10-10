#### Init

```java

using (SentrySdk.Init(o =>
{
    o.Dsn = "https://c9f149c50f4b40b98191e621f79e3669@sentry.io/1294828";
    o.Release = "kombucha-client@0.0.1"
})
{
    // app code here
}
```

#### Capturing

```java

using Sentry;

try 
{
    AFunctionThatMightFail();
} 
catch (Exception err)
{
    SentrySdk.CaptureException(err);
}

```