define(['jshamcrest', 'assert'], function (JsHamcrest, assert) {
    function serialize(o) {
        try {
            return JSON.stringify(o, null, 4);
        } catch (e) {
            return o;
        }
    }

    function structurallyEqualTo(value) {
        return new JsHamcrest.SimpleMatcher({
            matches: function (actual) {
                return assert.utils.deepCompare(value, actual);
            },
            describeTo: function (description) {
                description.append(serialize(value));
            },
            describeValueTo: function (actual, description) {
                description.append(serialize(actual));
            }
        });
    }

    return {
        structurallyEqualTo: structurallyEqualTo
    };
});