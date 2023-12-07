# odata-double-escape

Reproduce an issue for OData double unescaping.

Note you can retrieve an entity with key `key%3A` with the following URL:
`http://localhost:5150/xapi/v1/Foo(%27key%253A%27)`

On the other hand calling a function returns `key:`:
`http://localhost:5150/xapi/v1/Foo/MyFunction(fileName=%27key%253A%27)`

This is the issue
