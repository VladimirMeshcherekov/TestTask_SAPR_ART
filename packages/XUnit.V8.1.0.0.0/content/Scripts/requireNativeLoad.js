requirejs.load = function (context, moduleName, url) {
    try {
        console.log('Loading module ' + moduleName + ' with url ' + url);
        __v8ScriptLoader.Load(url);

        context.completeLoad(moduleName);
    } catch(ex) {
        context.onError('Could not load module ' + moduleName + ': ' + ex);
    }
}