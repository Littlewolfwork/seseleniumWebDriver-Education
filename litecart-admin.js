const {Builder, By, until} = require('selenium-webdriver');
const test = require('selenium-webdriver/testing');

test.describe('Google Search', function() {
    let driver;

    test.before(function *() {
        driver = yield new Builder().forBrowser('chrome').build();
    });

    // You can write tests either using traditional promises.
    it('works login admin', function() {
        return driver.get('http://localhost/litecart/admin/login.php')
            .then(_ => driver.findElement(By.name('username')).sendKeys('admin'))
            .then(_ => driver.findElement(By.name('password')).sendKeys('admin'))
            .then(_ => driver.findElement(By.className('btn btn-default')).click())
            .then(_ => driver.wait(until.titleIs('My Store'), 1000));
    });
    test.after(() => driver.quit());
});
