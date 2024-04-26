(window.webpackJsonp=window.webpackJsonp||[]).push([[28],{441:function(t,e,a){"use strict";a.r(e);var s=a(0),n=Object(s.a)({},(function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("ContentSlotsDistributor",{attrs:{"slot-key":t.$parent.slotKey}},[a("h1",{attrs:{id:"rate-limiter"}},[a("a",{staticClass:"header-anchor",attrs:{href:"#rate-limiter"}},[t._v("#")]),t._v(" Rate Limiter")]),t._v(" "),a("p",[t._v("A rate limiter is used to restrict the number of messages processed within a time period. The reason may be\nthat an API or service only accepts a certain number of calls per minute, and will delay any subsequent attempts\nuntil the rate limiting period has expired.")]),t._v(" "),a("div",{staticClass:"custom-block warning"},[a("p",{staticClass:"custom-block-title"},[t._v("WARNING")]),t._v(" "),a("p",[t._v("The rate limiter will delay message delivery until the rate limit expires, so it is best to avoid large time windows\nand keep the rate limits sane. Something like 1000 over 10 minutes is a bad idea, versus 100 over a minute. Try to\nadjust the values and see what works for you.")])]),t._v(" "),a("p",[t._v("There are two modes that a rate limiter can operate, but only of them is currently supported (the other may come later).")]),t._v(" "),a("p",[t._v("To add a rate limiter to a receive endpoint:")]),t._v(" "),a("div",{staticClass:"language-csharp extra-class"},[a("pre",{pre:!0,attrs:{class:"language-csharp"}},[a("code",[t._v("cfg"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("ReceiveEndpoint")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),a("span",{pre:!0,attrs:{class:"token string"}},[t._v('"customer_update_queue"')]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(",")]),t._v(" e "),a("span",{pre:!0,attrs:{class:"token operator"}},[t._v("=>")]),t._v("\n"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("{")]),t._v("\n    e"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("UseRateLimit")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),a("span",{pre:!0,attrs:{class:"token number"}},[t._v("1000")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(",")]),t._v(" TimeSpan"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("FromSeconds")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),a("span",{pre:!0,attrs:{class:"token number"}},[t._v("5")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(";")]),t._v("\n    "),a("span",{pre:!0,attrs:{class:"token comment"}},[t._v("// other configuration")]),t._v("\n"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("}")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(";")]),t._v("\n")])])]),a("p",[t._v("The two arguments supported by the rate limiter include:")]),t._v(" "),a("h3",{attrs:{id:"ratelimit"}},[a("a",{staticClass:"header-anchor",attrs:{href:"#ratelimit"}},[t._v("#")]),t._v(" RateLimit")]),t._v(" "),a("p",[t._v("The number of calls allowed in the time period.")]),t._v(" "),a("h3",{attrs:{id:"interval"}},[a("a",{staticClass:"header-anchor",attrs:{href:"#interval"}},[t._v("#")]),t._v(" Interval")]),t._v(" "),a("p",[t._v("The time interval before the message count is reset to zero.")])])}),[],!1,null,null,null);e.default=n.exports}}]);