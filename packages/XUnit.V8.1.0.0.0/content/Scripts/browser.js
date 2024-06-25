Date = Date || {};

Date.now = function () {
    return new Date().getTime();
};

navigator = {
    userAgent: 'Mozilla/5.0 (Windows NT 6.1; Intel Mac OS X 10.6; rv:7.0.1) Gecko/20100101 Firefox/7.0.1'
};

DomDocument = function () {
    var self = this;
    self.createElement = function () { return self; };
    self.getElementById = function () { return null; };
    self.write = function () { return self; };
    self.createEvent = function () { return {}; };
    self.createTextNode = function () { return self; };
    self.createComment = function () { return self; };
    self.getElementsByTagName = function () { return []; };
    self.body = {
        appendChild: function () { return {}; }
    };

    self.setAttribute = function () { return {}; };
    self.insertBefore = function () {

    };

    self.removeChild = function () {

    };

    self.appendChild = function () {
        return self;
    };

    self.createDocumentFragment = function () {
        return self;
    };

    self.addEventListener = function () {

    };
    
    self.nodeType = 9;

    self.cloneNode = function() {
        return self;
    };

    self.lastChild = self;

    self.style = {};
};

document = new DomDocument();
document.documentElement = new DomDocument();

window = this;

window.addEventListener = function () {

}