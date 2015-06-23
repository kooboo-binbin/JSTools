var Menu = function (selector, event) {
    var self = this;
    self.selector = selector;
    self.event = event;
    self.loadFunc = loadFunc;
    self.saveFunc = saveFunc;
};
var menuMenu = {
    selector: "ul>li",
    event: "click",
    items: [
        { name: "", label: "", value: "" },
        {}],
    show: function () {
        alert('show Menu');
    },
    loadFunc: function () {
        console.log("load");
    },
    saveFunc: function () {
        console.log("save");
    }
};
var testMenu = {
    selector: ".test-2",
    event: "mousedown",
    items: [
        { name: "", label: "", value: "" },
        {}],
    show: function (e) {
        alert('test2');
    },
    loadFunc: function () {
        console.log("load");
    },
    saveFunc: function () {
        console.log("save");
    }
};
var menus = [menuMenu, testMenu];
