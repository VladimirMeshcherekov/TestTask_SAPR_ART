define(['jshamcrest'], function (JsHamcrest) {
    function valueIsUndefined(o) {
        return typeof o === "undefined";
    }
    
    function isFunction(obj, functionName) {
        var typeName = typeof obj[functionName];
        var result = (typeName === 'function');
        return result;
    }

    function serialize(o) {
        try {
            return JSON.stringify(o, null, 4);
        } catch (e) {
            return o;
        }
    }

    function isTrue(test, message) {
        if (!test) throw message || 'assert.isTrue failure.';
    }
    
    function isFalse(test, message) {
        if (test) throw message || 'assert.isFalse failure.';
    }
    
    //taken and modified from: http://stackoverflow.com/questions/1068834/object-comparison-in-javascript
    function deepCompare(left, right) {
        function compare2Objects(x, y, leftChain, rightChain) {
            if (valueIsUndefined(x) && !valueIsUndefined(y) || !valueIsUndefined(x) && valueIsUndefined(y)) return false;
            
            //if the object has a custom serialization format, compare that instead
            if (x && isFunction(x, 'toJSON') && y && isFunction(y, 'toJSON')) return x.toJSON() === y.toJSON();
            
            var p;

            // remember that NaN === NaN returns false
            // and isNaN(undefined) returns true
            if (isNaN(x) && isNaN(y) && typeof x === 'number' && typeof y === 'number') {
                return true;
            }

            // Compare primitives and functions.     
            // Check if both arguments link to the same object.
            // Especially useful on step when comparing prototypes
            if (x === y) {
                return true;
            }

            // Works in case when functions are created in constructor.
            // Comparing dates is a common scenario. Another built-ins?
            // We can even handle functions passed across iframes
            if ((typeof x === 'function' && typeof y === 'function') ||
               (x instanceof Date && y instanceof Date) ||
               (x instanceof RegExp && y instanceof RegExp) ||
               (x instanceof String && y instanceof String) ||
               (x instanceof Number && y instanceof Number)) {
                return x.toString() === y.toString();
            }


            // check for infinitive linking loops
            if (leftChain.indexOf(x) > -1 || rightChain.indexOf(y) > -1) {
                return true;
            }
            
            function isPropertyDefined(o, prop) {
                return o.hasOwnProperty(prop) && !valueIsUndefined(o[prop]);
            }
            
            // Quick checking of one object beeing a subset of another.
            // todo: cache the structure of arguments[0] for performance
            for (p in y) {
                if (isPropertyDefined(y, p) !== isPropertyDefined(x, p)) {
                    return false;
                }
            }

            for (p in x) {
                switch (typeof (x[p])) {
                    case 'object':
                    case 'function':

                        var newLeftChain = leftChain.slice(0);
                        newLeftChain.push(x);
                        
                        var newRightChain = rightChain.slice(0);
                        newRightChain.push(y);

                        if (!compare2Objects(x[p], y[p], newLeftChain, newRightChain)) {
                            return false;
                        }

                        break;
                    default:
                        if (x[p] !== y[p]) {
                            return false;
                        }
                        break;
                }
            }

            return true;
        }

        return compare2Objects(left, right, [], []);
    }
    
    function equal(expected, actual, message) {
        if (!deepCompare(expected, actual)) throw message || 'assert.equal failed. Expected:\r\n' + serialize(expected) + '\r\n\r\nActual:\r\n' + serialize(actual);
    }
    
    function isNull(actual, message) {
        if (actual !== null) throw message || 'assert.isNull failure.';
    }
    
    function isNotNull(actual, message) {
        if (actual === null) throw message || 'assert.isNotNull failure.';
    }
    
    function isUndefined(actual, message) {
        if (typeof actual !== "undefined") throw message || "assert.isUndefined failure.";
    }

    function isDefined(actual, message) {
        if (typeof actual === "undefined") throw message || "assert.isDefined failure.";
    }
    
    function hasProperty(obj, property, message) {
        if (typeof obj[property] === "undefined") throw message || ('Expected value ' + property + ' to be defined but it was not');
    }
    
    function throwsException(action, message) {
        try {
            action();
        }
        catch (ex) {
            return ex;
        }

        throw message || "assert.throws failed.";
    }
    
    function doesNotThrowException(action, message) {
        try {
            action();
        } catch (ex) {
            throw message || 'Expected: no exception to be thrown, but got: "' + ex.toString() + '"';
        }
    }
    
    function hasPropertyOfType(obj, prop, expectedType, message) {
        var actual = obj[prop];
        var result = actual instanceof expectedType;

        function getFunctionName(fn) {
            var name = /\W*function\s+([\w\$]+)\(/.exec(fn);
            if (!name) return 'Unknown name';
            return name[1];
        }

        hasProperty(obj, prop, message);
        if (!result) throw message || ('Expected property "' + prop + '" to be of type ' + getFunctionName(expectedType) + ' but it was ' + getFunctionName(actual.constructor));
    }
    
    function assertIsFunction(obj, func, message) {
        if (!isFunction(obj, func)) throw message || ('Expected ' + func + ' to be a function but it was ' + expected);
    }
    
    function isArray(value, message) {
        if (!Array.isArray(value)) throw message || ('Expected an array but got: ' + value);
    }
    
    function that(actualValue, matcherOrValue, message) {
        return JsHamcrest.Operators.assert(actualValue, matcherOrValue, {
            message: message,
            fail: function (failMessage) {
                throw failMessage;
            },
            pass: function (passMessage) {

            }
        });
    }

    return {
        isTrue: isTrue,
        isFalse: isFalse,
        equal: equal,
        isNull: isNull,
        isNotNull: isNotNull,
        isUndefined: isUndefined,
        isDefined: isDefined,
        'throws': throwsException,
        doesNotThrow: doesNotThrowException,
        hasProperty: hasProperty,
        hasPropertyOfType: hasPropertyOfType,
        isFunction: assertIsFunction,
        isArray: isArray,
        that: that,
        utils: {
            deepCompare: deepCompare
        }
    };
});